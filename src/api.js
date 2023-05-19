import {HttpClient} from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';


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

  obterEnderecoDoServidor(){
    return "http://localhost:3000";
  }
}