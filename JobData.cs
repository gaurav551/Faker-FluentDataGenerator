using System.ComponentModel.DataAnnotations;

namespace JobsCatalog.Seeder
{
    public class JobData
    {
         public  string[] Tags {get;set;} = {"laravel,js,php","microsoft,aspnetn,azure","react,node,express"
                  ,"commiication,english,hospitality"
                  ,"doctor,hospital,nurse","dbms,mysql,amazon","aws,software,engineering"};
         public  string[] JobTypes {get;set;} = {"FullTime", "PartTime", "Internship", "Remote", "Freelance" };
         public string[] JobLocations { get; set; } = {"Birtamode", "Kathmandu", "NewYork","Biratnagar","Bhadrapur"};
         public string[] JobCategories { get; set; } = {"Fulltime","Part-Time","Freelancing","Remote","Contract"};
        
    

        // public  JobCategory JobCategories{get;set;}
        // public  JobType JobTypes{get;set;}
        // public  JobLocation JobLocations{get;set;}
        
    }
}
