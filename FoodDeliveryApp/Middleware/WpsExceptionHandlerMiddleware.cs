using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Net;
using System.Text.Json;
using Wps.WebApi.Middlewares.Exceptions;

public class WpsExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public WpsExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (WpsException wex)
        {
            await HandleException(context, wex);
        }

        catch (DbUpdateException dbEx)
        {
            await HandleDatabaseException(context, dbEx);
        }
    }

    private async Task HandleException(HttpContext context, WpsException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)exception.StatusCode;

        var response = new
        {
            exception.Message,
            exception.StatusCode
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private async Task HandleDatabaseException(HttpContext context, DbUpdateException dbException)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var databaseErrorMessage = GetDatabaseErrorMessage(dbException);

        var response = new
        {
            Message = "An error occurred while processing the request.",
            Details = databaseErrorMessage,
            StatusCode = HttpStatusCode.InternalServerError
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private string GetDatabaseErrorMessage(DbUpdateException dbException)
    {
        var errorMessage = "An error occurred while saving changes to the database.";

        if (dbException.InnerException is PostgresException postgresException)
        {
            errorMessage = $"PostgreSQL Error: {postgresException.Message}";
        }

        return errorMessage;
    }
}
