entity frameworkcore code to database first
1. install-package
	1) install-package Microsoft.EntityFrameworkcore.SqlServer
	2) install-package Microsoft.EntityFrameworkcore.Tools
2.scaffold-dbcontext
	1) Scaffold-DbContext -f "Server=(localdb)\MSSQLLocalDB;database=JWDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
