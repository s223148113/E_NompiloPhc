using E_NompiloPhc.Areas.Identity.Data;
using E_NompiloPhc.Models.FamilyPlanning;
using E_NompiloPhc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using E_NompiloPhc.Models.Referrals;
using E_NompiloPhc.Models.Nutrition;
using System.Reflection.Emit;
using E_NompiloPhc.Models.GBV;
using Microsoft.Build.Evaluation;
using E_NompiloPhc.Controllers;

namespace E_NompiloPhc.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    //public DbSet<ProjectRole> ProjectRoles { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<MedicalSupplyGroup> MedicalSupplyGroups { get; set; }
    public DbSet<MedicalSupplyProfile> MedicalSupplyProfiles { get; set; }

    public DbSet<MedicalSupply> MedicalSupplies { get; set; }

    public DbSet<HealthProvider> HealthProviders { get; set; }

    //public  DbSet<RefHeader> RefHeaders { get; set; }
    public DbSet<RefDetail> RefDetails { get; set; }

    public DbSet<Currency> Currencies { get; set; }

    public DbSet<Bill> Bills { get; set; }

    //family Planning data application
    public DbSet<Appointment> Appointments { get; set; }
    //public DbSet<User> Users { get; set; }
    public DbSet<FertilityData> FertilityData { get; set; }
    public DbSet<ContraceptiveMethod> ContraceptiveMethods { get; set; }
    public DbSet<Contraceptive> Contraceptives { get; set; }
    public DbSet<ContraceptivePreferencesViewModel> ContraceptivePreferencesViewModels { get; set; }
    public DbSet<CounselingResource> CounselingResources { get; set; }
    public DbSet<Counselor> Counselors { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<FertilityDataViewModel> FertilityDataViewModels { get; set; }
    public DbSet<FertilityInsights> FertilityInsights { get; set; }
    public DbSet<FertilityInsightsViewModel> FertilityInsightsViewModels { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<UserInputModel> UserInputModels { get; set; }
    public DbSet<UserPreference> UserPreferences { get; set; }
    public DbSet<UserTrackingModel> UserTrackingModels { get; set; }
    public DbSet<AppointmentViewModel> AppointmentViewModels { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientViewModel> patientViewModels { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        //builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        builder.Entity<UserInputModel>().HasNoKey();
        builder.Entity<AppointmentViewModel>().HasNoKey();
        builder.Entity<ContraceptivePreferencesViewModel>().HasNoKey();
        builder.Entity<FertilityDataViewModel>().HasNoKey();
        builder.Entity<FertilityInsightsViewModel>().HasNoKey();

        //referral
        //builder.Entity<RefHeader>()
        //            .HasOne(rh => rh.RefDetails)
        //            .WithMany()
        //            .HasForeignKey(rh => rh.BaseCurrency)
        //            .IsRequired()
        //            .OnDelete(DeleteBehavior.Cascade);




        //builder.Entity<Patient>()
        //            .HasOne(p => p.User)
        //            .WithMany()
        //            .HasForeignKey(p => p.UserId)
        //            .IsRequired()
        //            .OnDelete(DeleteBehavior.Cascade);
    }
    public override DbSet<IdentityRole>? Roles { get; set; }
    
    public DbSet<UserAppointment>? VirtualAppointment { get; set; }
    public DbSet<PHCMedicationRefill>? PHCMedicationRefill { get; set; }
    public DbSet<PatientMedicationRefill>? PatientMedicationRefill { get; set; }
    public DbSet<CheckUp>? CheckUp { get; set; }
    public DbSet<StaffLogTime>? StaffLogTime { get; set; }
    public DbSet<RefillDelivery>? MedicationRefillDelivery { get; set; }

    //Nutrition
    //public IQueryable<PatientInfo>? PatientInfo { get; set; }
    public DbSet<PatientInfo> PatientInfos { get; set; }
    public DbSet<SocialH> SocialHistory { get; set; }
    public DbSet<FamilyH> FamilyHistory { get; set; }
    public DbSet<SGA> SGA { get; set; }
    ////public IQueryable<SGA>? SGArecord { get; set; }
    ////public IQueryable<FamilyH>? FamilyH { get; set; }
    ////public IQueryable<SocialH>? SocialHistoryRecord { get; set; }
    public DbSet<Screening>? Screening { get; set; }
    public DbSet<Screening2>? Screening2 { get; set; }
    public DbSet<MacroNutrients>? MacroNutrients { get; set; }
    public DbSet<DietaryInfo>? DietaryInfos { get; set; }
    public DbSet<Biochemicals> Biochemicals { get; set; }
    public DbSet<Anthropometry> Antropometry { get; set; }
    public DbSet<FoodItems> FoodItems { get; set; }
    public DbSet<FoodExchange> FoodExchange { get; set; }
    public virtual DbSet<FoodExchange> DietFood { get; set; }
    public DbSet<DietaryInfo>? DietaryInfo { get; set; }
}
