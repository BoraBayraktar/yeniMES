using MES.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;

namespace MES.DB
{
    public partial class MesContext : DbContext
    {
        public virtual DbSet<MENU> MENU { get; set; }

        public virtual DbSet<AD_CUSTOMERS> AD_CUSTOMERS { get; set; }
        public virtual DbSet<HOLDING> HOLDING { get; set; }
        public virtual DbSet<COMPANY> COMPANY { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENT { get; set; }
        public virtual DbSet<TITLE> TITLE { get; set; }
        public virtual DbSet<USER> USER { get; set; }
        public virtual DbSet<USER_TYPE> USER_TYPE { get; set; }
        public virtual DbSet<USER_GROUP> USER_GROUP { get; set; }
        public virtual DbSet<COUNTRY> COUNTRY { get; set; }
        public virtual DbSet<REGION> REGION { get; set; }
        public virtual DbSet<CITY> CITY { get; set; }
        public virtual DbSet<LOCATION> LOCATION { get; set; }


        public virtual DbSet<LEAVE> LEAVE { get; set; }
        public virtual DbSet<LEAVE_TYPE> LEAVE_TYPE { get; set; }
        public virtual DbSet<WORKING_SCHEDULE> WORKING_SCHEDULE { get; set; }


        public virtual DbSet<MAIL_SERVER_SETUP> MAIL_SERVER_SETUP { get; set; }

        public virtual DbSet<TIME_MANAGEMENT> TIME_MANAGEMENT { get; set; }
        public virtual DbSet<TIME_MANAGEMENT_OFFDAYS> TIME_MANAGEMENT_OFFDAYS { get; set; }

        public virtual DbSet<WORKING_DAYS> WORKING_DAYS { get; set; }
        public virtual DbSet<TIMEZONE> TIMEZONE { get; set; }


        public virtual DbSet<SURVEY> SURVEY { get; set; }
        public virtual DbSet<SURVEY_QUESTION> SURVEY_QUESTION { get; set; }
        public virtual DbSet<SURVEY_QUESTION_ANSWER> SURVEY_QUESTION_ANSWER { get; set; }
        public virtual DbSet<SURVEY_HISTORY> SURVEY_HISTORY { get; set; }


        public virtual DbSet<EMAIL_TEMPLATE> EMAIL_TEMPLATE { get; set; }

        public virtual DbSet<EMAIL_TEMPLATE_PARAMETERS> EMAIL_TEMPLATE_PARAMETERS { get; set; }

        public virtual DbSet<DOMAIN> DOMAIN { get; set; }

        public virtual DbSet<MAIN_PROCESS> MAIN_PROCESS { get; set; }
        public virtual DbSet<SERVICECATALOG> SERVICECATALOG { get; set; }
        public virtual DbSet<GROUP> GROUP { get; set; }
        public virtual DbSet<GROUP_TYPE> GROUP_TYPE { get; set; }
        public virtual DbSet<GROUP_EXPERT> GROUP_EXPERT { get; set; }
        public virtual DbSet<KNOWLEDGE_MANAGEMENT> KNOWLEDGE_MANAGEMENT { get; set; }
        public virtual DbSet<KNOWLEDGE_FILES> KNOWLEDGE_FILES { get; set; }
        public virtual DbSet<ORDER_NUMBERS> ORDER_NUMBERS { get; set; }
        public virtual DbSet<KNOWLEDGE_SETTINGS> KNOWLEDGE_SETTINGS { get; set; }
        public virtual DbSet<SLA> SLA { get; set; }
        public virtual DbSet<SLA_EVENTS> SLA_EVENTS { get; set; }
        public virtual DbSet<SLA_AREA> SLA_AREA { get; set; }



        public virtual DbSet<PARAMETER> PARAMETER { get; set; }
        public virtual DbSet<PARAMETER_TYPE> PARAMETER_TYPE { get; set; }
        public virtual DbSet<MAIL_TO_SEND> MAIL_TO_SEND { get; set; }
        public virtual DbSet<PASSWORD_CHANGE_HISTORY> PASSWORD_CHANGE_HISTORY { get; set; }

        public virtual DbSet<GENERAL_SETTINGS> GENERAL_SETTINGS { get; set; }

        public virtual DbSet<INCIDENT> INCIDENT { get; set; }
        public virtual DbSet<INCIDENT_FILES> INCIDENT_FILES { get; set; }
        public virtual DbSet<INCIDENT_HISTORY> INCIDENT_HISTORY { get; set; }
        public virtual DbSet<INCIDENT_TYPE> INCIDENT_TYPE { get; set; }
        public virtual DbSet<USERTYPE_MENU> USERTYPE_MENU { get; set; }
        public virtual DbSet<INCIDENT_RESOLUTION> INCIDENT_RESOLUTION { get; set; }


        public virtual DbSet<RULE> RULE { get; set; }
        public virtual DbSet<RULE_CRITERIA> RULE_CRITERIA { get; set; }
        public virtual DbSet<LDAP_INFO> LDAP_INFO { get; set; }

        public virtual DbSet<RULE_ACTIONS> RULE_ACTIONS { get; set; }

        public virtual DbSet<RULE_DETAIL> RULE_DETAIL { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //AppConfiguration appConfiguration = new AppConfiguration();
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=.;Database=MesDB;Trusted_Connection=True;");
                ////optionsBuilder.UseSqlServer(appConfiguration.ConnectionString);
                //optionsBuilder.UseSqlServer(appConfiguration.ConnectionString);
                optionsBuilder.UseSqlServer("Server =.\\MSSQLSERVER01; Database = MES; user Id = admin; password = 12345678;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

           

            modelBuilder.Entity<USERTYPE_MENU>()
                .HasKey(x => new { x.UserTypeId, x.MenuId });

            modelBuilder.Entity<USERTYPE_MENU>()
                .HasOne(x => x.USER_TYPE)
                .WithMany(y => y.USERTYPE_MENUS)
                .HasForeignKey(y => y.UserTypeId);

            modelBuilder.Entity<USERTYPE_MENU>()
                .HasOne(x => x.MENU)
                .WithMany(y => y.USERTYPE_MENUS)
                .HasForeignKey(y => y.MenuId);

            base.OnModelCreating(modelBuilder);



            //modelBuilder.Entity<SURVEY_QUESTION_ANSWER>()
            //    .Property(q => q.EVALUATION_1)
            //    .HasDefaultValue(false);
            //modelBuilder.Entity<SURVEY_QUESTION_ANSWER>()
            //    .Property(q => q.EVALUATION_2)
            //    .HasDefaultValue(false);
            //modelBuilder.Entity<SURVEY_QUESTION_ANSWER>()
            //    .Property(q => q.EVALUATION_3)
            //    .HasDefaultValue(false);
            //modelBuilder.Entity<SURVEY_QUESTION_ANSWER>()
            //    .Property(q => q.EVALUATION_4)
            //    .HasDefaultValue(false);
            //modelBuilder.Entity<SURVEY_QUESTION_ANSWER>()
            //    .Property(q => q.EVALUATION_5)
            //    .HasDefaultValue(false);
            //modelBuilder.Entity<SURVEY_QUESTION_ANSWER>()
            //    .Property(q => q.BINARY_OPTION_1)
            //    .HasDefaultValue(false);
            //modelBuilder.Entity<SURVEY_QUESTION_ANSWER>()
            //    .Property(q => q.BINARY_OPTION_2)
            //    .HasDefaultValue(false);
        }


    }
}

