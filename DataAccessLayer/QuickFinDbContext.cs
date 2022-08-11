using System;
using Microsoft.EntityFrameworkCore;
using QuickFin.Models;

namespace DataAccessLayer
{
    public partial class QuickFinDbContext : DbContext
    {
        private readonly string _connectionString;

        public QuickFinDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountType> AccountTypes { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<CurrencyConversion> CurrencyConversions { get; set; } = null!;
        public virtual DbSet<EquityCurrentValue> EquityCurrentValues { get; set; } = null!;
        public virtual DbSet<EquityDetail> EquityDetails { get; set; } = null!;
        public virtual DbSet<Family> Families { get; set; } = null!;
        public virtual DbSet<InvestmentAccountExtenstion> InvestmentAccountExtenstions { get; set; } = null!;
        public virtual DbSet<InvestmentTransaction> InvestmentTransactions { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<TransactionType> TransactionTypes { get; set; } = null!;
        public virtual DbSet<TransferMapping> TransferMappings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.AccountName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("account_name");

                entity.Property(e => e.AccountType)
                    .HasColumnType("integer")
                    .HasColumnName("account_type");

                entity.Property(e => e.AcountNo)
                    .HasColumnType("bigint")
                    .HasColumnName("acount_no");

                entity.Property(e => e.CurrencyId)
                    .HasColumnType("integer")
                    .HasColumnName("currency_id");

                entity.Property(e => e.CurrentBalance)
                    .HasColumnType("integer")
                    .HasColumnName("current_balance");

                entity.Property(e => e.UserId)
                    .HasColumnType("integer")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.AccountTypeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountType);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CurrencyId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("account_types");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.AccountType1)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("account_type");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("currency");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.CurrencyName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("currency_name");
            });

            modelBuilder.Entity<CurrencyConversion>(entity =>
            {
                entity.ToTable("currency_conversion");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.DestinationCurrencyId)
                    .HasColumnType("integer")
                    .HasColumnName("destination_currency_id");

                entity.Property(e => e.SourceCurrencyId)
                    .HasColumnType("integer")
                    .HasColumnName("source_currency_id");

                entity.HasOne(d => d.DestinationCurrency)
                    .WithMany(p => p.CurrencyConversionDestinationCurrencies)
                    .HasForeignKey(d => d.DestinationCurrencyId);

                entity.HasOne(d => d.SourceCurrency)
                    .WithMany(p => p.CurrencyConversionSourceCurrencies)
                    .HasForeignKey(d => d.SourceCurrencyId);
            });

            modelBuilder.Entity<EquityCurrentValue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("equity_current_value");

                entity.Property(e => e.CurrentValue)
                    .HasColumnType("real")
                    .HasColumnName("current_value");

                entity.Property(e => e.EquityName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("equity_name");
            });

            modelBuilder.Entity<EquityDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("equity_details");

                entity.Property(e => e.Isinno).HasColumnName("ISINNo");

                entity.Property(e => e.IsubgroupName).HasColumnName("ISubgroupName");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("family");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.FamilyName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("family_name");
            });

            modelBuilder.Entity<InvestmentAccountExtenstion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Investment_account_extenstion");

                entity.Property(e => e.AccountId)
                    .HasColumnType("integer")
                    .HasColumnName("account_id");

                entity.Property(e => e.RealisedPnl)
                    .HasColumnType("real")
                    .HasColumnName("realised_pnl");

                entity.Property(e => e.UnrealisedPnl)
                    .HasColumnType("real")
                    .HasColumnName("unrealised_pnl");

                entity.HasOne(d => d.Account)
                    .WithMany()
                    .HasForeignKey(d => d.AccountId);
            });

            modelBuilder.Entity<InvestmentTransaction>(entity =>
            {
                entity.ToTable("investment_transactions");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("integer")
                    .HasColumnName("account_id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.EquityName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("equity_name");

                entity.Property(e => e.Price)
                    .HasColumnType("real")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity)
                    .HasColumnType("integer")
                    .HasColumnName("quantity");

                entity.Property(e => e.TransactionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("transaction_time");

                entity.Property(e => e.TransactionType)
                    .HasColumnType("integer")
                    .HasColumnName("transaction_type");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.InvestmentTransactions)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.TransactionTypeNavigation)
                    .WithMany(p => p.InvestmentTransactions)
                    .HasForeignKey(d => d.TransactionType);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("integer")
                    .HasColumnName("account_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("real")
                    .HasColumnName("amount");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("integer")
                    .HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.TransactionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("transaction_time");

                entity.Property(e => e.TransactionTypeId)
                    .HasColumnType("integer")
                    .HasColumnName("transaction_type_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.TransactionTypeId);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("transaction_type");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.TransactionName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("transaction_name");
            });

            modelBuilder.Entity<TransferMapping>(entity =>
            {
                entity.ToTable("transfer_mapping");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.CurrencyConversionId)
                    .HasColumnType("integer")
                    .HasColumnName("currency_conversion_id");

                entity.Property(e => e.DestinationTransactionId)
                    .HasColumnType("integer")
                    .HasColumnName("destination_transaction_id");

                entity.Property(e => e.SourceTransactionId)
                    .HasColumnType("integer")
                    .HasColumnName("source_transaction_id");

                entity.HasOne(d => d.CurrencyConversion)
                    .WithMany(p => p.TransferMappings)
                    .HasForeignKey(d => d.CurrencyConversionId);

                entity.HasOne(d => d.DestinationTransaction)
                    .WithMany(p => p.TransferMappingDestinationTransactions)
                    .HasForeignKey(d => d.DestinationTransactionId);

                entity.HasOne(d => d.SourceTransaction)
                    .WithMany(p => p.TransferMappingSourceTransactions)
                    .HasForeignKey(d => d.SourceTransactionId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnType("integer")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EmailId)
                    .HasColumnType("email_id")
                    .HasColumnName("email_id");

                entity.Property(e => e.FamilyId)
                    .HasColumnType("integer")
                    .HasColumnName("family_id");

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("full_name");

                entity.Property(e => e.Password)
                    .HasColumnType("password")
                    .HasColumnName("password");

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FamilyId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

