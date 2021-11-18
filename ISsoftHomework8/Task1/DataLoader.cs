using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Task1
{
    public class DataLoader
    {
        private readonly SqlConnection _connection;

        public DataLoader(string connectionString) => _connection = new(connectionString);

        public void Load(string filepath)
        {
            filepath = Path.Combine(Environment.CurrentDirectory, filepath);
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException($"{filepath} not found");
            }

            ClearTable("VACATION");
            ClearTable("EMPLOYEE");

            var records = GetRecords(filepath);
            foreach (var employee in records.GroupBy(r => r.Name))
            {
                var id = Guid.NewGuid();
                var name = employee.Key.Split(" ", StringSplitOptions.TrimEntries);
                SaveEmployee(id, name[0], name[1]);
                foreach (var vacation in employee)
                {
                    SaveVacation(Guid.NewGuid(), vacation.Start, vacation.End, id);
                }
            }
        }

        private void ClearTable(string tableName)
        {
            var sql = $"DELETE FROM {tableName}";
            var cmd = new SqlCommand(sql, _connection);

            _connection.Open();
            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        private List<(string Name, DateTime Start, DateTime End)> GetRecords(string filepath)
        {
            var records = new List<(string, DateTime, DateTime)>();

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            using var sr = new StreamReader(filepath);
            string line;
            var i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                i++;
                try
                {
                    var data = line.Split(",");
                    records.Add((data[0], DateTime.Parse(data[1]), DateTime.Parse(data[2])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Line {i}: {ex.Message}");
                }
            }

            return records;
        }

        private void SaveEmployee(Guid id, string name, string surname)
        {
            var sql = "INSERT INTO Employee(Id, Name, Surname, Email) " +
                "VALUES(@Id, @Name, @Surname, @Email)";
            var cmd = new SqlCommand(sql, _connection);

            cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@Id"].Value = id;

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
            cmd.Parameters["@Name"].Value = name;

            cmd.Parameters.Add("@Surname", SqlDbType.NVarChar);
            cmd.Parameters["@Surname"].Value = surname;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
            cmd.Parameters["@Email"].Value = $"{name}{surname}@issoft.by";

            _connection.Open();
            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        private void SaveVacation(Guid id, DateTime start, DateTime end, Guid employeeId)
        {
            var sql = "INSERT INTO Vacation(Id, StartDate, EndDate, EmployeeId) " +
                "VALUES(@Id, @Start, @End, @EmployeeId)";
            var cmd = new SqlCommand(sql, _connection);

            cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@Id"].Value = id;

            cmd.Parameters.Add("@Start", SqlDbType.Date);
            cmd.Parameters["@Start"].Value = start;

            cmd.Parameters.Add("@End", SqlDbType.Date);
            cmd.Parameters["@End"].Value = end;

            cmd.Parameters.Add("@EmployeeId", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@EmployeeId"].Value = employeeId;

            _connection.Open();
            cmd.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
