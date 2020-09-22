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
                for (int i = 0; i < 10000; i++)
                {
                    Job j = new Job();
                    j = SeedJobs();

                    _context.Jobs.Add(j);
                    _context.SaveChanges();

                }
            }
            return Task.CompletedTask;
        }
        
        public Job SeedJobs()
        {
             var lorem = new Bogus.DataSets.Lorem(locale: "en");
            var jobposteruserId = "dab6f06c-72f8-4912-81b5-ebde1588c8be";
            var testjobs = new Faker<Job>()
            .CustomInstantiator(f => new Job())
            
           .RuleFor(u => u.City, f => f.Address.City())
           .RuleFor(u => u.MaxSalary, f => f.Random.Number(50000, 100000))
           .RuleFor(u => u.MinSalary, f => f.Random.Number(100, 30000))
           .RuleFor(u => u.Opening, f => f.Random.Number(1, 15))
           .RuleFor(u => u.Email, (f, u) => f.Internet.Email())
           .RuleFor(u => u.PostedBy, (f, u) => jobposteruserId)
           .RuleFor(u => u.Title, f => f.Name.JobTitle())
           .RuleFor(u => u.PostedOn, (f, u) => f.Date.Past())
           .RuleFor(u => u.Status, (f, u) => true)
           .RuleFor(u => u.Tags, f => f.PickRandom(Tags))
           .RuleFor(u => u.Requirement, f => f.Lorem.Paragraphs(5))
           .RuleFor(u => u.Responsibility, f => f.Lorem.Paragraphs())
           .RuleFor(u => u.Experience, f => f.Random.Number(1, 5))
           .RuleFor(u => u.Category, f => f.PickRandom(JobCategories))
           .RuleFor(u => u.Type, f => f.PickRandom(JobTypes))
           .RuleFor(u => u.Location, f => f.PickRandom(JobLocations))
           .RuleFor(u => u.Description, f => lorem.Paragraphs(5))
           .RuleFor(u => u.Benefits, f => f.Lorem.Paragraphs(5))
           .RuleFor(u => u.Deadline, (f, u) => f.Date.Future());
           var data = testjobs.Generate();
            return data;



            //Use a method outside scope.

        }


    }
}
