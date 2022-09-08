using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DomainModel.Models;

namespace FlightManagementBlazorServer.Services
{
    public class PassengerService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseApiUrl = "https://localhost:44334/api/Passenger";

        public PassengerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task AddPassenger(Passenger passenger)
        {
            var httpPostRequest = new HttpRequestMessage(HttpMethod.Post, BaseApiUrl);
            httpPostRequest.Content = new StringContent(JsonSerializer.Serialize(passenger), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPostRequest);
        }

        public async Task<List<Passenger>> GetPassengersAsync(int flightId)
        {
            return await _httpClient.GetFromJsonAsync<List<Passenger>>($"{BaseApiUrl}/{flightId}");

        }

        public async Task DeletePassengerAsync(int passengerId)
        {
            var request =new HttpRequestMessage(HttpMethod.Delete, $"{BaseApiUrl}/{passengerId}");
            await _httpClient.SendAsync(request);
        }

        public async Task UpdatePassengerAsync(Passenger passenger)
        {
            var httpPostRequest = new HttpRequestMessage(HttpMethod.Put, BaseApiUrl);
            httpPostRequest.Content = new StringContent(JsonSerializer.Serialize(passenger), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPostRequest);
        }


        public async Task CheckOutPassengerAsync(int passengerId)
        {
            var httpPostRequest = new HttpRequestMessage(HttpMethod.Put, $"{BaseApiUrl}/CheckOutPassenger/{passengerId}");
            await _httpClient.SendAsync(httpPostRequest);
        }

        public async Task<Passenger> GetPassengerAsync(int passengerId)
        {
           
            return await _httpClient.GetFromJsonAsync<Passenger>($"{BaseApiUrl}/GetPassenger/{passengerId}");
        }

        public async Task<List<Passenger>> GetCheckedPassengersAsync(int flightId)
        {
            return await _httpClient.GetFromJsonAsync<List<Passenger>>($"{BaseApiUrl}/GetCheckedPassengers/{flightId}");

        }

        public async Task CheckInPassengerAsync(Passenger passenger)
        {
            var httpPostRequest = new HttpRequestMessage(HttpMethod.Put, $"{BaseApiUrl}/CheckInPassenger");
            httpPostRequest.Content = new StringContent(JsonSerializer.Serialize(passenger), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPostRequest);
        }

    }
}
