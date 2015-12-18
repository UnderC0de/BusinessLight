using BusinessLight.PhoneBook.Domain;

namespace BusinessLight.PhoneBook.Data
{
    using System.Data.Entity;

    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext()
            : base("name=PhoneBookDbContext")
        {
        }

        public virtual DbSet<Contact> Contacts
        {
            get; 
            set;
        }

        /// <summary>
        /// Tale metodo viene chiamato dopo l'inizializzazione del modello di un contesto derivato, ma prima che il modello sia stato bloccato e utilizzato per inizializzare il contesto.L'implementazione predefinita di questo metodo non esegue alcuna operazione, ma è possibile eseguirne l'override in una classe derivata in modo da poter configurare ulteriormente il modello prima che venga bloccato.
        /// </summary>
        /// <param name="modelBuilder">Generatore che definisce il modello per il contesto creato.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
              .Entity<ContactInfo>()
              .HasRequired(x => x.Contact)
              .WithMany(x => x.ContactInfos)
              .HasForeignKey(x => x.ContactId);

            base.OnModelCreating(modelBuilder);
        }
    }
}