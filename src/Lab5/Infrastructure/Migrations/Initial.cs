using FluentMigrator;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Migrations;

[Migration(1, "Initial")]
public class Initial : Migration
{
    public override void Up()
    {
        Execute.Sql(
            """
            create table users
            (
                id bigint primary key generated always as identity,
                password text not null,
                balance money not null default 0,
            );

            create table history
            (
                transaction_id bigint primary key generated always as identity,
                id bigint not null references accounts(account_id) on delete cascade,
                transaction_type text not null check (transaction_type in ('deposit', 'withdrawal')),
                amount money not null,
            );
            """);
    }

    public override void Down()
    {
        Execute.Sql(
            """
            drop table transactions;
            drop table accounts;
            """);
    }
}