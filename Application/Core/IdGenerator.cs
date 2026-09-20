using System;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core
{
    /// <summary>
    /// Tự động sinh mã ID theo format: Prefix + số thứ tự (3 chữ số).
    /// Ví dụ: GetNextId("KhachHang", "MaKH", "KH") → "KH036"
    /// </summary>
    public static class IdGenerator
    {
        public static string GetNextId(string tableName, string columnName, string prefix)
        {
            string newId = prefix + "001";

            string query = string.Format(
                "SELECT TOP 1 {0} FROM {1} ORDER BY CAST(SUBSTRING({0}, {2}, LEN({0}) - {3}) AS INT) DESC",
                columnName, tableName, prefix.Length + 1, prefix.Length);

            object result = DatabaseHelper.ExecuteScalar(query);

            if (result != null && result != DBNull.Value)
            {
                string lastId = result.ToString().Trim();
                string numberPart = lastId.Substring(prefix.Length);
                if (int.TryParse(numberPart, out int number))
                {
                    number++;
                    newId = prefix + number.ToString("D3");
                }
            }

            return newId;
        }
    }
}
