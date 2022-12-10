using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using webapi.Controllers;
using webapi.Models;

namespace webapi.Test;
public class UnitTest1
{
    [Theory(DisplayName = "Testes De transferência")]
    [InlineData(1, 10, 201, "1")]
    [InlineData(2, 10, 400, "2")]
    [InlineData(2, 100, 400, "3")]
    public async void Test1(int payer, int value, int codeStatus, string database)
    {
        var context = AppDbContextTest.StartDb(database);

        Transaction payload = new Transaction
        {
            Value = value,
            Payer = payer, //Usuário tipo
            Payee = 3 //Logista
        };

        TransactionController controller = new TransactionController(context);
        var result = await controller.Transaction(payload) as ObjectResult;
        var actualResult = result.StatusCode;

        Assert.Equal(codeStatus, actualResult);
    }


}