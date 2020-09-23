using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using JobHub.Data;
using JobHub.Models;

namespace JobsCatalog.Seeder
{
    public class Seeder : JobData
    {
        private readonly ApplicationDbContext _context;
        public Seeder(ApplicationDbContext context)
        {
            _context = context;

        }
        public Task SeedData()
        {
           System.Console.WriteLine(SeedJobs().Description);
           
           System.Console.WriteLine(SeedJobs().Benefits);
           
           System.Console.WriteLine("Running");
            if (!_context.Jobs.Any())
            {
               int i = 0;
               while(i<10000)
               {
                    Job j = new Job();
                    j = SeedJobs();

                    _context.Jobs.Add(j);
                    _context.SaveChanges();
                    i++;

                };
             }
              
            
            return Task.CompletedTask;
        }
        
        public Job SeedJobs()
        {
           var lorem = new Lorem(locale: "en");
            
            var testjobs = new Faker<Job>()
            .CustomInstantiator(f => new Job())
            
           .RuleFor(u => u.City, f => f.Address.City())
           .RuleFor(u => u.MaxSalary, f => f.Random.Number(1000, 200000))
           .RuleFor(u => u.MinSalary, f => f.Random.Number(1000, 80000))
           .RuleFor(u => u.Opening, f => f.Random.Number(1, 15))
           .RuleFor(u => u.Email, (f, u) => f.Internet.Email())
           .RuleFor(u => u.PostedBy, f => f.PickRandom(JobPosterUserIds))
           .RuleFor(u => u.Title, f => f.Name.JobTitle())
           .RuleFor(u => u.PostedOn, (f, u) => f.Date.Past())
           .RuleFor(u => u.Status, (f, u) => true)
           .RuleFor(u => u.Tags, f => f.PickRandom(Tags))
           .RuleFor(u => u.Requirement, f => lorem.Paragraphs(5))
           .RuleFor(u => u.Responsibility, f => lorem.Paragraphs(5))
           .RuleFor(u => u.Experience, f => f.Random.Number(1, 5))
           .RuleFor(u => u.Category, f => f.PickRandom(JobCategories))
           .RuleFor(u => u.Type, f => f.PickRandom(JobTypes))
           .RuleFor(u => u.Location, f => f.PickRandom(JobLocations))
           .RuleFor(u => u.Description, f => lorem.Paragraphs(5))
           .RuleFor(u => u.Benefits, f => lorem.Paragraphs(5))
           .RuleFor(u => u.Deadline, (f, u) => f.Date.Future());
           var data = testjobs.Generate();
            return data;



            //Use a method outside scope.

        }


    }
}
