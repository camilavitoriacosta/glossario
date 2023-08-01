import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';


@inject(HttpClient)
export class Api {

  constructor(http) {
    this.http = http;
  }

  get(url) {
    return this.http.fetch(this.obterEnderecoDoServidor() + url, {
      method: 'get',
    });
  }

  post(url, corpo) {
    return this.http.fetch(this.obterEnderecoDoServidor() + url, {
      method: 'post',
      body: json(corpo)
    });
  }

  put(url, corpo) {
    return this.http.fetch(this.obterEnderecoDoServidor() + url, {
      method: 'put',
      body: json(corpo)
    });
  }

  obterEnderecoDoServidor(){
    return "https://localhost:7088/api/";
  }  
}