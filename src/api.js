import {HttpClient} from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import { json } from 'aurelia-fetch-client';


@inject(HttpClient)
export class Api{

  constructor(http){
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

  obterEnderecoDoServidor(){
    return "http://localhost:3000";
  }
}