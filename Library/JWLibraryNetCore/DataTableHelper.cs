using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public static class DataTableHelper
{
    public static List<TEntity> ToList<TEntity>(this DataTable datatable) where TEntity : new()
    {
        var dataList = new List<TEntity>();

        const System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Public |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;

        var objFieldNames = (
                            from System.Reflection.PropertyInfo aProp in typeof(TEntity).GetProperties(flags)
                            select new {Name = aProp.Name, Type = System.Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType}
                            ).ToList();

        var dataTbFieldNames = (from DataColumn aHeader in datatable.Columns
                                select new { Name = aHeader.ColumnName, Type = aHeader.DataType }).ToList();

        var commonFields = objFieldNames.Intersect(dataTbFieldNames).ToList();

        foreach(DataRow dr in datatable.Rows)
        {
            var aTEntity = new TEntity();
            foreach(var aField in commonFields)
            {
                System.Reflection.PropertyInfo propertyInfos = aTEntity.GetType().GetProperty(aField.Name.ToUpper());
                var value = (dr[aField.Name] == System.DBNull.Value ? null : dr[aField.Name]);
                propertyInfos.SetValue(aTEntity, value, null);
            }

            dataList.Add(aTEntity);
        }

        return dataList;
    }

    public static DataTable ToDatatable(this string json)
    {
        return JsonConvert.DeserializeObject<DataTable>(json);
    }

    public static JObject ToJObject(this DataTable datatable)
    {
        return JObject.FromObject(datatable);
    }

    public static JArray ToJArray(this DataTable datatable)
    {
        return (JArray)JsonConvert.SerializeObject(datatable);
    }
}