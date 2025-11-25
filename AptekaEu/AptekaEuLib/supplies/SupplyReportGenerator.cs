using System.IO;
using System.Text;

namespace AptekaEuLib.supplies
{
    public class SupplyReportGenerator
    {
        public string GenerateSupplyReport(Supply supply)
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang='ru'>");
            html.AppendLine("<head>");
            html.AppendLine("    <meta charset='UTF-8'>");
            html.AppendLine("    <title>Приходная накладная</title>");
            html.AppendLine("    <style>");
            html.AppendLine("        body {");
            html.AppendLine("            font-family: 'Times New Roman', serif;");
            html.AppendLine("            margin: 0;");
            html.AppendLine("            padding: 0;");
            html.AppendLine("            display: flex;");
            html.AppendLine("            justify-content: center;");
            html.AppendLine("        }");
            html.AppendLine("        .page {");
            html.AppendLine("            width: 700px;");
            html.AppendLine("            padding: 40px 20px;");
            html.AppendLine("        }");
            html.AppendLine("        .header {");
            html.AppendLine("            text-align: center;");
            html.AppendLine("            margin-bottom: 20px;");
            html.AppendLine("        }");
            html.AppendLine("        .header-title {");
            html.AppendLine("            font-size: 28px;");
            html.AppendLine("            font-weight: bold;");
            html.AppendLine("        }");
            html.AppendLine("        .number {");
            html.AppendLine("            font-size: 20px;");
            html.AppendLine("            font-weight: bold;");
            html.AppendLine("            margin-top: 20px;");
            html.AppendLine("        }");
            html.AppendLine("        .date {");
            html.AppendLine("            font-size: 16px;");
            html.AppendLine("            margin-top: 20px;");
            html.AppendLine("        }");
            html.AppendLine("        .separator {");
            html.AppendLine("            width: 100%;");
            html.AppendLine("            height: 2px;");
            html.AppendLine("            background: black;");
            html.AppendLine("            margin: 30px 0;");
            html.AppendLine("        }");
            html.AppendLine("        table {");
            html.AppendLine("            width: 100%;");
            html.AppendLine("            border-collapse: collapse;");
            html.AppendLine("            font-size: 15px;");
            html.AppendLine("            border: 2px solid #000;");
            html.AppendLine("        }");
            html.AppendLine("        th, td {");
            html.AppendLine("            border: 1px solid #000;");
            html.AppendLine("            padding: 6px 8px;");
            html.AppendLine("            text-align: center;");
            html.AppendLine("        }");
            html.AppendLine("        th {");
            html.AppendLine("            font-weight: bold;");
            html.AppendLine("            background-color: #f2f2f2;");
            html.AppendLine("        }");
            html.AppendLine("        .total {");
            html.AppendLine("            margin-top: 30px;");
            html.AppendLine("            font-size: 18px;");
            html.AppendLine("            font-weight: bold;");
            html.AppendLine("            text-align: right;");
            html.AppendLine("        }");
            html.AppendLine("        .signature-block {");
            html.AppendLine("            margin-top: 80px;");
            html.AppendLine("            text-align: right;");
            html.AppendLine("            font-size: 14px;");
            html.AppendLine("        }");
            html.AppendLine("        .signature-line {");
            html.AppendLine("            display: inline-block;");
            html.AppendLine("            width: 200px;");
            html.AppendLine("            border-bottom: 1px solid #000;");
            html.AppendLine("            margin-bottom: 5px;");
            html.AppendLine("        }");
            html.AppendLine("    </style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("    <div class='page'>");

            // Заголовок
            html.AppendLine("        <div class='header'>");
            html.AppendLine("            <div class='header-title'>ПРИХОДНАЯ НАКЛАДНАЯ</div>");
            html.AppendLine($"            <div class='number'>№ {supply.SerialNumber}</div>");
            html.AppendLine($"            <div class='date'>Дата: {supply.DeliveryDate:dd.MM.yyyy}</div>");
            html.AppendLine("        </div>");

            html.AppendLine("        <div class='separator'></div>");

            // Поставщик
            html.AppendLine("        <div style='font-size: 18px; margin-bottom: 25px; text-align: left; line-height: 1.5;'>");
            html.AppendLine($"            <strong>Поставщик:</strong> {supply.Supplier.Name}<br>");
            html.AppendLine($"            <strong>ИНН:</strong> {supply.Supplier.Tin}<br>");
            html.AppendLine($"            <strong>Контактное лицо:</strong> {supply.Supplier.ContactPerson}<br>");
            html.AppendLine($"            <strong>Адрес:</strong> {supply.Supplier.Address}<br>");
            html.AppendLine($"            <strong>Телефон:</strong> {supply.Supplier.Phone}");
            html.AppendLine("        </div>");

            // Таблица товаров
            html.AppendLine("        <table>");
            html.AppendLine("            <thead>");
            html.AppendLine("                <tr>");
            html.AppendLine("                    <th>Артикул</th>");
            html.AppendLine("                    <th>Наименование</th>");
            html.AppendLine("                    <th>Категория</th>");
            html.AppendLine("                    <th>Количество</th>");
            html.AppendLine("                    <th>Цена</th>");
            html.AppendLine("                    <th>Единица измерения</th>");
            html.AppendLine("                    <th>Сумма</th>");
            html.AppendLine("                </tr>");
            html.AppendLine("            </thead>");
            html.AppendLine("            <tbody>");

            foreach (var item in supply.Items)
            {
                html.AppendLine("                <tr>");
                html.AppendLine($"                    <td>{item.Product.Id}</td>");
                html.AppendLine($"                    <td>{item.Product.Name}</td>");
                html.AppendLine($"                    <td>{item.Category.Name}</td>");
                html.AppendLine($"                    <td>{item.Quantity}</td>");
                html.AppendLine($"                    <td>{item.UnitPrice:N2}</td>");
                html.AppendLine("                    <td>шт</td>");
                html.AppendLine($"                    <td>{item.TotalCost:N2}</td>");
                html.AppendLine("                </tr>");
            }

            html.AppendLine("            </tbody>");
            html.AppendLine("        </table>");

            // Итог
            html.AppendLine($"        <div class='total'>Общая сумма накладной: {supply.TotalCost:N2} руб</div>");

            // Подпись
            html.AppendLine("        <div class='signature-block'>");
            html.AppendLine("            <div class='signature-line'></div><br>");
            html.AppendLine("            (подпись)");
            html.AppendLine("        </div>");

            html.AppendLine("    </div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString();
        }


        public void SaveReportToFile(Supply supply, string filePath)
        {
            string htmlContent = GenerateSupplyReport(supply);
            File.WriteAllText(filePath, htmlContent, Encoding.UTF8);
        }
    }
}