using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

public class UserRepository: BaseRepository, IUserRepository
{
    private readonly string TableName = "Users";

    public UserRepository(IConfiguration configuration) : base(configuration)
    { }

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            var query = $"INSERT INTO {TableName} (Username, Password, Email, Phone) VALUES (@Username, @Password, @Email, @Phone)";

            var parameters = new DynamicParameters();
            parameters.Add("Username", entity.Username, DbType.String);
            parameters.Add("Password", Encryption.MD5(entity.Password), DbType.String);
            parameters.Add("Email", entity.Email, DbType.String);
            parameters.Add("Phone", entity.Phone, DbType.String);

            using(var connection = CreateConnection())
            {
                return (await connection.ExecuteAsync(query, parameters));
            }
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<int> DeleteAsync(User entity)
    {
        try
        {
            var query = $"DELETE FROM {TableName} WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id, DbType.Int32);

            using(var connection = CreateConnection())
            {
                return (await connection.ExecuteAsync(query, parameters));
            }
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<User>> GetAllAsync()
    {
        try
        {
            var query = $"SELECT * FROM {TableName}";

            using(var connection = CreateConnection())
            {
                return (await connection.QueryAsync<User>(query)).ToList();
            }
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<User> GetByIdAsync(int id)
    {
        try
        {
            var query = $"SELECT * FROM {TableName} WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using(var connection = CreateConnection())
            {
                return (await connection.QueryFirstOrDefaultAsync<User>(query, parameters));
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<int> UpdateAsync(User entity)
    {
        try
        {
            var query = $"UPDATE {TableName} SET Username = @Username, Email = @Email, Phone = @Phone WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id, DbType.Int32);
            parameters.Add("Username", entity.Username, DbType.String);
            parameters.Add("Email", entity.Email, DbType.String);
            parameters.Add("Phone", entity.Phone, DbType.String);

            using(var connection = CreateConnection())
            {
                return (await connection.ExecuteAsync(query, parameters));
            }
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}