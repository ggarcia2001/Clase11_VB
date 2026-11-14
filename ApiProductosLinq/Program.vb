Imports ApiProductosLinq.Data
Imports ApiProductosLinq.Repositories
Imports ApiProductosLinq.Services
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Module Program

    Sub Main(args As String())
        Dim builder As WebApplicationBuilder = WebApplication.CreateBuilder(args)

        Dim connectionString As String = builder.Configuration.GetConnectionString("DefaultConnection")

        builder.Services.AddDbContext(Of AppDbContext)(Sub(options) options.UseSqlServer(connectionString))
        builder.Services.AddScoped(Of ICategoriaRepository, CategoriaRepository)()
        builder.Services.AddScoped(Of IProductoRepository, ProductoRepository)()
        builder.Services.AddScoped(Of IProductoService, ProductoService)()
        builder.Services.AddControllers()
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()

        Dim app As WebApplication = builder.Build()

        If app.Environment.IsDevelopment() Then
            app.UseSwagger()
            app.UseSwaggerUI()
        End If

        app.UseHttpsRedirection()
        app.UseAuthorization()
        app.MapControllers()

        app.Run()
    End Sub

End Module
