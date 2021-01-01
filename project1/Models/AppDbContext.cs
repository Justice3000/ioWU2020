using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace project1{
    public class AppDbContext:IdentityDbContext<IdentityUser>{
        public AppDbContext(DbContextOptions<AppDbContext>options) : base (options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Item> Items {get; set;}
        public DbSet<Project> Projects {get; set;}

        protected override void OnModelCreating(ModelBuilder mb) //mb from now on stands for model builder
        {
        base.OnModelCreating(mb);
 
        //MY PRECIOUS SEED hahahaha

   
//seeding items
     mb.Entity<Item>().HasData(new Item
        {
            ItemId = 1,
            Name = "PELLETSKAMIN ADURO P2 SVART",
            SupplierName = "BAUHAUS",
            SupplierPrice = 24995,
            Quantity = 4,
            Url = "https://www.bauhaus.se/pelletskamin-aduro-p2-svart",
            LongImportantInfo = @"Enkel och kubisk design kryddad med integrerad wifi-modul som gör kaminen särskilt användarvänlig. Slå på värmen på vägen hem från jobbet eller semestern, så är det varmt innan du kliver innanför dörren. Hos Aduro P2 har fläkten ersatts med naturlig konvektion, precis som hos en vanlig braskamin, vilket ger tystare drift. Även pelletsbehållaren är speciell och kan lätt fyllas på via en låda på sidan av kaminen.
Installationen är enkel och okomplicerad med både topp- och bakutgång som alternativ. Aduro P2 är lufttät och kan därför installeras överallt. Kaminen har möjlighet till extern lufttillförsel, där luften till förbränningen tillförs utifrån och direkt in i pelletskaminen. Aduro P2 är målad med matt pulverlack.
Tänk på att kontrollera, efter installation, att beslagen är åtdragna samt att packningarna är korrekt placerade.",
            ProjectId = 1,
            ItemOwner = "dani@indreika.se"
            
        });

mb.Entity<Item>().HasData(new Item
        {
            ItemId = 5,
            Name = "Antennkabel för fönstergenomföring",
            SupplierName = "BILTEMA",
            SupplierPrice = 79.90,
            Quantity = 40,
            Url = "https://www.biltema.se/kontor---teknik/bild/antenner/antennkablar/antennkabel-for-fonstergenomforing-2000033285",
            LongImportantInfo = "Platt koaxialkabel med F-kontakt, hona-hona. Placeras enkelt under ett stängt fönster så att man slipper göra hål när man ska dra en antennkabel från en utomhusantenn. 75 Ω impedans. 50-2250 MHz. Färg: Vit. Längd: 20 cm.",
            ProjectId = 1,
            ItemOwner = "dani@indreika.se"
            
        });
        mb.Entity<Item>().HasData(new Item
        {
            ItemId = 2,
            Name = "Donna Matgrupp med 4 stolar",
            SupplierName = "MIO",
            SupplierPrice = 3646,
            Quantity = 2,
            Url = "https://www.mio.se/p/donna-matgrupp-med-4-stolar/M1860157",
            LongImportantInfo = "Den marmormönstrade glasskivan är minst lika vacker som äkta natursten, men är mer lättskött och beständig mot smuts och vätskor. Donna har en lätt vadderad sits och rygg, klädd i mjuk sammet och tunna ben i lackerad metall.",
            ProjectId = 1,
            ItemOwner = "dani@indreika.se"
            
        });

        mb.Entity<Item>().HasData(new Item
        {
            ItemId = 3,
            Name = "MDF Closet Bi-Fold Door",
            SupplierName = "Home Depot",
            SupplierPrice = 650.86,
            Quantity = 4,
            Url = "https://www.homedepot.com/p/24-in-x-80-in-Colonist-Primed-Textured-Molded-Composite-MDF-Closet-Bi-Fold-Door-THDJW160600147/202037481",
            LongImportantInfo = @"Bi-fold closet door includes hardware installation kit and knobs
Door trimmable for custom fit up to 1/4in T, 3/4in B & 1/8in S
Bi-fold closet door fits 24 in. W x 80 to 80-7/8 in. H opening",
            ProjectId = 2,
            ItemOwner = "dani@indreika.se"
            
        });
mb.Entity<Item>().HasData(new Item
        {
            ItemId = 4,
            Name = "CM-BEATRICE",
            SupplierName = "Interiör Collection",
            SupplierPrice = 1700,
            Quantity = 10,
            Url = "https://images.hermanmiller.group/m/b79f4b3c94638cb1/W-PD_1390_314909.png?blend-mode=darken&blend=f8f8f8&trim-color=ffffff&trim=color&bg=f8f8f8&auto=format&w=2000&h=1000&q=60",
            LongImportantInfo = @"Upholstered armchair with gentle curves and foam support.
Swivel base turns 360 degrees.
Chair tilts back for lounging.",
            ProjectId = 3,
            ItemOwner = "dani@indreika.se"
            
        });


//seeding projects
      mb.Entity<Project>().HasData(new Project
       {
           ProjectId = 1,
           Name = "Test Project #1",
           Description = "This is project for testing purposes #1",
           ProjectOwner = "dani@indreika.se"
    
       });
       
        mb.Entity<Project>().HasData(new Project
       {
           ProjectId = 2,
           Name = "Test Project #2",
           Description = "This is project for testing purposes #2",
           ProjectOwner = "dani@indreika.se"
       });

        mb.Entity<Project>().HasData(new Project
       {
           ProjectId = 3,
           Name = "Test Project #3",
           Description = "This is project for testing purposes #3",
           ProjectOwner = "dani@indreika.se"
       });


//seeding roles
        mb.Entity<IdentityRole>().HasData(
        new IdentityRole{
            Id = "4bc6375a-3db6-476d-9565-db3e5cdafbf3",
            Name = "admin",
            NormalizedName = "ADMIN"
        });

        mb.Entity<IdentityRole>().HasData(
        new IdentityRole{
            Id = "4bc6375a-3db6-476d-9565-db3e5cdafbf4",
            Name = "manager",
            NormalizedName = "MANAGER"
        });

        mb.Entity<IdentityRole>().HasData(
        new IdentityRole{
            Id = "4bc6375a-3db6-476d-9565-db3e5cdafbf5",
            Name = "user",
            NormalizedName = "USER"
        });


       

      
        
        
        }

        

    }
}