using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    public class Startup
    {
        static void Main(string[] args)
        {
            using (var context = new StudentSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();   
            }
        }
    }
}
