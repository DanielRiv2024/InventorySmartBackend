using Dapper;
using Dapper.Oracle;
using InventorySmart.Interface;
using InventorySmart.Models;
using System.Data;

namespace InventorySmart.Services
{
    public class LotService : ILot
    {
        private readonly IConfiguration _configuration;
        private readonly OracleConecctionManager _connectionManager;
        public LotService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionManager = new OracleConecctionManager(configuration);
        }
        public async Task<Lot> CreateLot(Lot lot)
        {
            using (var connection = await _connectionManager.OpenConnectionAsync())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_StartDate", lot.startTime);
                parameters.Add("p_SaleDate", lot.saleTime);
                parameters.Add("p_Quanty", lot.quanty);
                parameters.Add("p_UnitPrice", lot.unitPrice);
                parameters.Add("p_FinalPrice", lot.finalPrice);
                parameters.Add("p_CreatedBy", lot.createdBy);
                parameters.Add("p_UpdatedBy", lot.updateBy);
                parameters.Add("p_IdProduct", lot.idProduct);
                var result = await connection.ExecuteAsync("CreateLot", parameters, commandType: CommandType.StoredProcedure);
                return lot; 
            }
        }

        public bool DeleteLot(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Lot>> GetAllLots()
        {
            using (var connection = await _connectionManager.OpenConnectionAsync())
            {

                var result = await connection.QueryAsync<dynamic>("SELECT * FROM LOT");
                var lotList = result.ToList();

                Console.WriteLine("Lista de Lotes:");
                foreach (var lot in lotList)
                {
                    Console.WriteLine($"Lote: {lot}");
                }

                var results = await connection.QueryAsync<Lot>("SELECT * FROM LOT");
                return results.ToList();
            }
        }

        public Task<Lot> GetLotById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Lot> UpdateLot(Lot lot)
        {
            using (var connection = await _connectionManager.OpenConnectionAsync())
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_LotId", lot.idLot, (OracleMappingType?)DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_StartDate", lot.startTime, (OracleMappingType?)DbType.Date, ParameterDirection.Input);
                parameters.Add("p_SaleDate", lot.saleTime, (OracleMappingType?)DbType.Date, ParameterDirection.Input);
                parameters.Add("p_Quanty", lot.quanty, (OracleMappingType?)DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_UnitPrice", lot.unitPrice, (OracleMappingType?)DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_FinalPrice", lot.finalPrice, (OracleMappingType?)DbType.Decimal, ParameterDirection.Input);
                parameters.Add("p_UpdatedBy", lot.updateBy, (OracleMappingType?)DbType.String, ParameterDirection.Input);

                var result = await connection.ExecuteAsync("UpdateLot", parameters, commandType: CommandType.StoredProcedure);

                return lot;
            }
        }

    }
}
