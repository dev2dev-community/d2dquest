using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Diagnostics;
using D2DQuest.ObjectDomain;

namespace D2DQuest.DataAccessLayer
{
    public class D2DQuestDbContext: DbContext
    {
        public D2DQuestDbContext(string connectionStringOrName)
            :base(connectionStringOrName)
        {
#if DEBUG
            Database.Log = sql => Debug.Write(sql);
#endif
        }

        public IDbSet<KeyWord> Words { get; set; }

        public IDbSet<Visiter> Visiters { get; set; }

        public IDbSet<WordRegistration> Registrations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visiter>()
                .Property(v => v.Uid)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, 
                    new IndexAnnotation(
                        new IndexAttribute("IX_Uid") { IsUnique = true }));

            modelBuilder.Entity<WordRegistration>()
                .HasRequired(wr => wr.Visiter);

            modelBuilder.Entity<WordRegistration>()
                .HasRequired(wr => wr.Word);

            modelBuilder.Entity<KeyWord>()
                .Property(w => w.Word)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Word") {IsUnique = true}));

            base.OnModelCreating(modelBuilder);
        }
    }
}
