using GestaoOcorrencias.Web.Models;
using GestaoOcorrencias.Web.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace GestaoOcorrencias.Web.Controllers
{
    public class OcorrenciaController : Controller
    {
        private readonly string ENDPOINTOCORRENCIA = "";
        private readonly string ENDPOINTCLIENTE = "";
        private readonly HttpClient httpclient = null;
        private static List<OcorrenciaDto> _ocorrencias = new List<OcorrenciaDto>() { };

        private readonly IConfiguration _configuration;

        public OcorrenciaController(IConfiguration configuration)
        {
            httpclient = new HttpClient();
            _configuration = configuration;
            ENDPOINTOCORRENCIA = _configuration["AppConfig:Endpoints:Url_Api_Ocorrencia"];
            ENDPOINTCLIENTE = _configuration["AppConfig:Endpoints:Url_Api_Cliente"];
            httpclient.BaseAddress = new Uri(ENDPOINTOCORRENCIA);


        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Ocorrencias()
        {
            HttpResponseMessage response = await httpclient.GetAsync(ENDPOINTOCORRENCIA);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<List<OcorrenciaDto>>(content);
                return View(lista);
            }
            else
            {
                ModelState.AddModelError(null, "Error");
            }
            return View(_ocorrencias);
        }

        public async Task<IActionResult> GetResponsavel()
        {
            HttpResponseMessage response = await httpclient.GetAsync(ENDPOINTCLIENTE);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lista = JsonConvert.DeserializeObject<List<ClienteDto>>(content);
                return new JsonResult(lista.Select(sel => new { sel.ClienteId, sel.Name}).ToList());
            }
            else
            {
                ModelState.AddModelError(null, "Error");
            }
            return View(_ocorrencias);
        }
        public async Task<IActionResult> Create(OcorrenciaDto ocorrencia)
        {
            try
            {
                string ResponsavelAbertura = Request.HasFormContentType ? Request.Form["ddlDepartment"] : "";
                if (ResponsavelAbertura != "" && ResponsavelAbertura != "0")
                {
                    ocorrencia.CodResponsavelAbertura = ResponsavelAbertura;
                    string json = JsonConvert.SerializeObject(ocorrencia);
                    byte[] buffer = Encoding.UTF8.GetBytes(json);
                    ByteArrayContent byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    string url = $"{ENDPOINTOCORRENCIA}/Abertura";
                    HttpResponseMessage response = await httpclient.PostAsync(url, byteContent);
                    if (response.IsSuccessStatusCode)
                    {

                    }
                    return RedirectToAction("Ocorrencias");
                }
                return View();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<IActionResult> Read(string Id)
        {
            try
            {
                if (Id != null)
                {
                    OcorrenciaDto Ocorrencia = null;
                    string url = $"{ENDPOINTOCORRENCIA}/Pesquisar/?id={Id}";
                    HttpResponseMessage response = await httpclient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Ocorrencia = JsonConvert.DeserializeObject<OcorrenciaDto>(content);
                    }
                    return View(Ocorrencia);
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<IActionResult> Update(Guid Id, OcorrenciaDto ocorrenciaUpdate, bool Update)
        {
            try
            {
                if (Id != null)
                {
                    OcorrenciaDto ocorrencia = null;
                    string url = $"{ENDPOINTOCORRENCIA}/Pesquisar/?id={Id}";
                    HttpResponseMessage response = await httpclient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        ocorrencia = JsonConvert.DeserializeObject<OcorrenciaDto>(content);
                    }
                    if (Update)
                    {
                        url = $"{ENDPOINTOCORRENCIA}/Atualizar/?Id={Id}";
                        string json = JsonConvert.SerializeObject(ocorrenciaUpdate);
                        byte[] buffer = Encoding.UTF8.GetBytes(json);
                        ByteArrayContent byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        response = await httpclient.PutAsync(url, byteContent);
                        if (response.IsSuccessStatusCode)
                        {

                        }
                        return RedirectToAction("Ocorrencias");
                    }

                    return View(ocorrencia);
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<IActionResult> Delete(string Id, bool Delete)
        {
            try
            {
                if (Id != null)
                {
                    OcorrenciaDto ocorrencia = null;
                    string url = $"{ENDPOINTOCORRENCIA}/Pesquisar/?id={Id}";
                    HttpResponseMessage response = await httpclient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        ocorrencia = JsonConvert.DeserializeObject<OcorrenciaDto>(content);
                    }
                    if (Delete)
                    {
                        url = $"{ENDPOINTOCORRENCIA}/Delete/?id={Id}";
                        HttpRequestMessage request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Delete,
                            RequestUri = new Uri(url)
                        };
                        await httpclient.SendAsync(request);
                        return RedirectToAction("Ocorrencias");
                    }

                    return View(ocorrencia);
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IActionResult> Avancar(Guid Id, OcorrenciaDto ocorrenciaUpdate, bool Update)
        {
            try
            {
                if (Id != null)
                {
                    OcorrenciaDto ocorrencia = null;
                    string url = $"{ENDPOINTOCORRENCIA}/Pesquisar/?id={Id}";
                    HttpResponseMessage response = await httpclient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        ocorrencia = JsonConvert.DeserializeObject<OcorrenciaDto>(content);
                    }
                    if (Update)
                    {
                        string ResponsavelAbertura = Request.HasFormContentType ? Request.Form["ddlDepartment"] : "";
                        ocorrencia.CodResponsavelAbertura = ResponsavelAbertura;
                        url = $"{ENDPOINTOCORRENCIA}/Avancar/?Id={Id}";
                        string json = JsonConvert.SerializeObject(ocorrencia);
                        byte[] buffer = Encoding.UTF8.GetBytes(json);
                        ByteArrayContent byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        response = await httpclient.PostAsync(url, byteContent);
                        if (response.IsSuccessStatusCode)
                        {

                        }
                        return RedirectToAction("Ocorrencias");
                    }

                    return View(ocorrencia);
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IActionResult> Fechar(Guid Id, OcorrenciaDto ocorrenciaUpdate, bool Update)
        {
            try
            {
                if (Id != null)
                {
                    OcorrenciaDto ocorrencia = null;
                    string url = $"{ENDPOINTOCORRENCIA}/Pesquisar/?id={Id}";
                    HttpResponseMessage response = await httpclient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        ocorrencia = JsonConvert.DeserializeObject<OcorrenciaDto>(content);
                    }
                    if (Update)
                    {
                        string ResponsavelAbertura = Request.HasFormContentType ? Request.Form["ddlDepartment"] : "";
                        ocorrencia.CodResponsavelAbertura = ResponsavelAbertura;
                        url = $"{ENDPOINTOCORRENCIA}/Fechar/?Id={Id}";
                        string json = JsonConvert.SerializeObject(ocorrencia);
                        byte[] buffer = Encoding.UTF8.GetBytes(json);
                        ByteArrayContent byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        response = await httpclient.PostAsync(url, byteContent);
                        if (response.IsSuccessStatusCode)
                        {

                        }
                        return RedirectToAction("Ocorrencias");
                    }

                    return View(ocorrencia);
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
