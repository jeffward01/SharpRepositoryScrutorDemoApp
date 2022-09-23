namespace SharpRepository.Scrutor.ConsoleApp.Client.Infra;

using Entities;
using Microsoft.EntityFrameworkCore;

public class SchoolContext: DbContext 
{
    public SchoolContext(): base()
    {
            
    }
            
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }
}