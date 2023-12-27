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

        public async Task<bool> DeleteLot(int lotId)
        {
            using (var connection = await _connectionManager.OpenConnectionAsync())
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_LotId", lotId, OracleMappingType.Decimal, ParameterDirection.Input);

                var result = await connection.ExecuteAsync("DeleteLot", parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public async Task<List<Lot>> GetLotsByProductId(int productId)
        {
            using (var connection = await _connectionManager.OpenConnectionAsync())
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_ProductId", productId, OracleMappingType.Decimal, ParameterDirection.Input);
                parameters.Add("p_Lots", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                var result = await connection.QueryAsync<Lot>("GetLotsByProductId", parameters, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<List<Lot>> GetAllLots()
        {
            using (var connection = await _connectionManager.OpenConnectionAsync())
            { 
                var results = await connection.QueryAsync<Lot>("SELECT * FROM LOT");
                return results.ToList();
            }
        }


        public async Task<Lot> UpdateLot(Lot lot)
        {
            using (var connection = await _connectionManager.OpenConnectionAsync())
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_LotId", lot.idLot, OracleMappingType.Decimal, ParameterDirection.Input);
                parameters.Add("p_StartDate", lot.startTime, OracleMappingType.Date, ParameterDirection.Input);
                parameters.Add("p_SaleDate", lot.saleTime, OracleMappingType.Date, ParameterDirection.Input);
                parameters.Add("p_Quanty", lot.quanty, OracleMappingType.Decimal, ParameterDirection.Input);
                parameters.Add("p_UnitPrice", lot.unitPrice, OracleMappingType.Decimal, ParameterDirection.Input);
                parameters.Add("p_FinalPrice", lot.finalPrice, OracleMappingType.Decimal, ParameterDirection.Input);
                parameters.Add("p_UpdatedBy", lot.updateBy, OracleMappingType.Varchar2, ParameterDirection.Input);

                var result = await connection.ExecuteAsync("UpdateLot", parameters, commandType: CommandType.StoredProcedure);

                return lot;
            }
        }

        public async Task<Lot> GetLotById(int lotId)
        {
            using (var connection = await _connectionManager.OpenConnectionAsync())
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("p_LotId", lotId, OracleMappingType.Decimal, ParameterDirection.Input);
                parameters.Add("p_Lot", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                var result = await connection.QueryFirstOrDefaultAsync<Lot>("GetLotById", parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

    }
}
