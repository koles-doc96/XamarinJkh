﻿using System;
using System.Net;
using System.Threading.Tasks;
using LibraryJkh.Server.RequestModel;
using RestSharp;

namespace LibraryJkh.Server
{
    public class RestClientMP
    {
        public const string SERVER_ADDR = "https://api.sm-center.ru/test_erc_udm"; // Адрес сервера
        public const string LOGIN_DISPATCHER = "auth/loginDispatcher"; // Аутификация сотрудника
        public const string LOGIN = "auth/Login"; // Аунтификация пользователя
        public const string REQUEST_CODE = "auth/RequestAccessCode"; // Запрос кода подтверждения
        public const string REGISTR_BY_PHONE = "auth/RegisterByPhone"; // Регистрация по телефону

        /// <summary>
        /// Аунтификация сотрудника
        /// </summary>
        /// <param name="login">Логин сотрудника</param>
        /// <param name="password">Пароль сотрудника</param>
        /// <returns>LoginResult</returns>
        public async Task<LoginResult> LoginDispatcher(string login, string password)
        {
            RestClient restClientMp = new RestClient(SERVER_ADDR);
            RestRequest restRequest = new RestRequest(LOGIN_DISPATCHER, Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(new
            {
                login,
                password,
            });
            var response = await restClientMp.ExecuteTaskAsync<LoginResult>(restRequest);
            // Проверяем статус
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new LoginResult()
                {
                    Error = $"Ошибка {response.StatusDescription}"
                };
            }

            return response.Data;
        }
        /// <summary>
        /// Аунтификация пользователя по номеру телефона
        /// </summary>
        /// <param name="phone">Номер телефона</param>
        /// <param name="password">Пароль</param>
        /// <returns>LoginResult</returns>
        public async Task<LoginResult> Login(string phone, string password)
        {
            RestClient restClientMp = new RestClient(SERVER_ADDR);
            RestRequest restRequest = new RestRequest(LOGIN, Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(new
            {
                phone,
                password,
            });
            var response = await restClientMp.ExecuteTaskAsync<LoginResult>(restRequest);
            // Проверяем статус
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new LoginResult()
                {
                    Error = $"Ошибка {response.StatusDescription}"
                };
            }

            return response.Data;
        }
        /// <summary>
        /// Запрос кода доступа
        /// </summary>
        /// <param name="phone">Номер телефона</param>
        /// <returns>CommonResult</returns>
        public async Task<CommonResult> RequestAccessCode(string phone)
        {
            Console.WriteLine("Запрос кода подтверждения");
            RestClient restClientMp = new RestClient(SERVER_ADDR);
            RestRequest restRequest = new RestRequest(REQUEST_CODE, Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(new
            {
                phone
            });
            var response = await restClientMp.ExecuteTaskAsync<CommonResult>(restRequest);
            // Проверяем статус
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new CommonResult()
                {
                    Error = $"Ошибка {response.StatusDescription}"
                };
            }
            Console.WriteLine(response.Data.Error);
            return response.Data;
        }

        /// <summary>
        /// Регистрация пользователя по номеру телефона
        /// </summary>
        /// <param name="fio">ФИО пользователя</param>
        /// <param name="phone">Номер телефона пользователя</param>
        /// <param name="password">Пароль</param>
        /// <param name="code">Код доступа необходимо запросить методом RequestAccessCode</param>
        /// <returns>CommonResult</returns>
        public async Task<CommonResult> RegisterByPhone(string fio, string phone, string password, string code)
        {
            RestClient restClientMp = new RestClient(SERVER_ADDR);
            RestRequest restRequest = new RestRequest(REGISTR_BY_PHONE, Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(new
            {
                fio,
                phone,
                password,
                code
            });
            var response = await restClientMp.ExecuteTaskAsync<CommonResult>(restRequest);
            // Проверяем статус
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new CommonResult()
                {
                    Error = $"Ошибка {response.StatusDescription}"
                };
            }

            return response.Data;
        }
    }
}