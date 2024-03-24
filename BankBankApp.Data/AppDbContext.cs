using System;
using System.Collections.Generic;
using BankBankApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankBankApp.Data
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
		{
		}

		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Account> Accounts { get; set; }

		public virtual DbSet<AccountType> AccountTypes { get; set; }

		public virtual DbSet<AccountsView> AccountsViews { get; set; }

		public virtual DbSet<Bill> Bills { get; set; }

		public virtual DbSet<Biller> Billers { get; set; }

		public virtual DbSet<Card> Cards { get; set; }

		public virtual DbSet<CardType> CardTypes { get; set; }

		public virtual DbSet<Role> Roles { get; set; }

		public virtual DbSet<Top5UsersWithLargestBalance> Top5UsersWithLargestBalances { get; set; }

		public virtual DbSet<Transaction> Transactions { get; set; }

		public virtual DbSet<TransactionCategory> TransactionCategories { get; set; }

		public virtual DbSet<User> Users { get; set; }

		public virtual DbSet<UserTransactionHistory> UserTransactionHistories { get; set; }

		public virtual DbSet<UserView> UserViews { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
			=> optionsBuilder.UseSqlServer("Data Source=.\\BSISQLEXPRESS;Initial Catalog=BankBank;Integrated Security=True;TrustServerCertificate=True;");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>(entity =>
			{
				entity.HasKey(e => e.AccountId).HasName("PK__Accounts__349DA5869185A0C1");

				entity.Property(e => e.Currency).HasDefaultValue("IDR");

				entity.HasOne(d => d.AccountType).WithMany(p => p.Accounts)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Accounts_AccountTypes");

				entity.HasOne(d => d.User).WithMany(p => p.Accounts)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Accounts_UserID");
			});

			modelBuilder.Entity<AccountType>(entity =>
			{
				entity.HasKey(e => e.AccountTypeId).HasName("PK__AccountT__8F95854F2D0E172B");
			});

			modelBuilder.Entity<AccountsView>(entity =>
			{
				entity.ToView("AccountsView", "Users");
			});

			modelBuilder.Entity<Bill>(entity =>
			{
				entity.HasKey(e => e.BillId).HasName("PK__Bills__11F2FC4A3C6928CE");

				entity.HasOne(d => d.Account).WithMany(p => p.Bills)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Bills_AccountID");

				entity.HasOne(d => d.Biller).WithMany(p => p.Bills)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Bills_BillerID");
			});

			modelBuilder.Entity<Biller>(entity =>
			{
				entity.HasKey(e => e.BillerId).HasName("PK__Billers__5239A7B37BC9399C");
			});

			modelBuilder.Entity<Card>(entity =>
			{
				entity.HasKey(e => e.CardId).HasName("PK__Cards__55FECD8EFC9789C8");

				entity.HasOne(d => d.CardType).WithMany(p => p.Cards)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_2");

				entity.HasOne(d => d.User).WithMany(p => p.Cards)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_1");
			});

			modelBuilder.Entity<CardType>(entity =>
			{
				entity.HasKey(e => e.CardTypeId).HasName("PK__CardType__AB0A3D314B829E4A");
			});

			modelBuilder.Entity<Role>(entity =>
			{
				entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AABC6B456");
			});

			modelBuilder.Entity<Top5UsersWithLargestBalance>(entity =>
			{
				entity.ToView("Top5UsersWithLargestBalance");
			});

			modelBuilder.Entity<Transaction>(entity =>
			{
				entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B809407C4");

				entity.HasOne(d => d.Bill).WithMany(p => p.Transactions).HasConstraintName("FK_Transactions_Bills");

				entity.HasOne(d => d.ReceiverAccount).WithMany(p => p.TransactionReceiverAccounts).HasConstraintName("FK_Transactions_ReceiverAccountID");

				entity.HasOne(d => d.SourceAccount).WithMany(p => p.TransactionSourceAccounts)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Transactions_SourceAccountID");

				entity.HasOne(d => d.TransactionCategory).WithMany(p => p.Transactions)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Transactions_TransactionCategoryID");
			});

			modelBuilder.Entity<TransactionCategory>(entity =>
			{
				entity.HasKey(e => e.TransactionCategoryId).HasName("PK__Transact__348808420C539649");
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC64B30725");

				entity.Property(e => e.LastLoginDate).HasDefaultValueSql("(getdate())");

				entity.HasMany(d => d.Roles).WithMany(p => p.Usernames)
					.UsingEntity<Dictionary<string, object>>(
						"UserRole",
						r => r.HasOne<Role>().WithMany()
							.HasForeignKey("RoleId")
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK_UserRoles_Roles"),
						l => l.HasOne<User>().WithMany()
							.HasPrincipalKey("Username")
							.HasForeignKey("Username")
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK_UserRoles_Users"),
						j =>
						{
							j.HasKey("Username", "RoleId");
							j.ToTable("UserRoles", "Users");
							j.IndexerProperty<string>("Username")
								.HasMaxLength(50)
								.IsUnicode(false);
							j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
						});
			});

			modelBuilder.Entity<UserTransactionHistory>(entity =>
			{
				entity.ToView("UserTransactionHistory");
			});

			modelBuilder.Entity<UserView>(entity =>
			{
				entity.ToView("UserView", "Users");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}