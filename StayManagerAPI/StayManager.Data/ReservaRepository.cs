using Dapper;
using Microsoft.AspNetCore.Mvc;
using StayManager.Data.DTO;
using StayManager.Data.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace StayManager.Data
{
    public class ReservaRepository
    {
        protected readonly string ConnectionString;

        public ReservaRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public async Task SalvarReserva(ReservaModel data)
        {
            const string query = @"INSERT INTO RESERVA(DATARESERVA, PERIODOINICIAL, PERIODOFINAL, TIPOQUARTO, NOMECLIENTE, VALORTOTAL, SERVICOSADICIONAIS) 
                           VALUES(@DataReserva, @PeriodoInicial, @PeriodoFinal, @TipoQuarto, @NomeCliente, @ValorTotal, @ServicosAdicionais)";
            try
            {
                await using var conn = GetOpenConnection();
                int affectedRows = await conn.ExecuteAsync(query, new
                {
                    DataReserva = data.DataReserva,
                    PeriodoInicial = data.PeriodoInicial,
                    PeriodoFinal = data.PeriodoFinal,
                    TipoQuarto = data.TipoQuarto,
                    NomeCliente = data.NomeCliente,
                    ValorTotal = data.ValorTotal,
                    ServicosAdicionais = data.ServicosExtras,
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir dados: {ex.Message}");
            }
        }

        public async Task DeletarReserva(int reservaId)
        {
            const string query = @"DELETE FROM RESERVA WHERE ID = @ReservaId";
            try
            {
                await using var conn = GetOpenConnection();
                int affectedRows = await conn.ExecuteAsync(query, new
                {
                   ReservaId = reservaId,
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar dados: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ReservaDTO>> ListarReservas()
        {
            const string query = @"SELECT * FROM RESERVA";
           
                await using var conn = GetOpenConnection();
                var reservas = await conn.QueryAsync<ReservaDTO>(query);
                return reservas;
        }
    }
}