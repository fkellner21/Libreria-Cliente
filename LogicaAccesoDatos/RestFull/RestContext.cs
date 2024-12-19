using Azure.Core;
using Infraestructura.LogicaAccesoDatos.RestFull;
using LogicaAccesoDatos.Excepciones;
using LogicaDeNegocio.Entidades;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace LogicaAccesoDatos.RestFull;

public class RestContext : IRestFull
{
    // Clase genérica RestContext que implementa la interfaz IRestFull
    private RestClient _httpClient;
    private string _apiUrl = "";
    private RestRequest _request;


    // Recibo por inyeccion la url y creo el cliente. Se acopla al conocimiento de RestSharp
    public RestContext(string apiUrl)
    {
        _apiUrl = apiUrl;
        // Inicializa la URL base de la API con el valor proporcionado.
        _httpClient = new RestClient(_apiUrl);
    }


    // Recibe el Recurso y devuelve el json son el resultado de la request
    public String Get(string token, string endPoint)
    {
        var _request = new RestRequest(endPoint);
        _request.AddHeader("Contet-Type", "application/json");
        if (token != "")
        {
            _request.AddHeader("Authorization", $"Bearer {token}");
        }
        var response = _httpClient.ExecuteGet(_request);
        if ((int)response.StatusCode == 204)
        {
            throw new EmptyException();
        }

        if ((int)response.StatusCode >= 300)
        {
            throw new Exception($"Hubo un error {response.StatusCode}");
        }

        if (response.Content == null)
        {
            throw new Exception("No se encontraron datos");
        }
        return response.Content;
    }

  
    // Recibe el Recurso y el json a dar de alta
    public string Post(string token, string endPoint, string json)
    {
        var _request = new RestRequest(endPoint);
        _request.AddHeader("Contet-Type", "application/json");
        if (token != "")
        {
            _request.AddHeader("Authorization", $"Bearer {token}");
        }
        _request.AddBody(json);
        var response = _httpClient.ExecutePost(_request);
        if ((int)response.StatusCode == 204)
        {
            throw new EmptyException();
        }
        if ((int)response.StatusCode >= 300)
        {
            throw new Exception($"Hubo un error {response.StatusCode}");
        }
        if (response.Content == null)
        {
            throw new Exception("No se encontraron datos");
        }
        return response.Content;
    }

    // Recibe el Recurso y devuelve el json son el resultado de la request
    public void Delete(string token, string endPoint)
    {
        var _request = new RestRequest(endPoint, Method.Delete);
        _request.AddHeader("Contet-Type", "application/json");
        _request.AddHeader("Authorization", $"Bearer {token}");
        _httpClient.Execute(_request);
    }

}



