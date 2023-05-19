import { inject } from 'aurelia-framework';
import { Api } from './api';

@inject(Api)
export class TermoApi{

  constructor(api){
    this.api = api;
  }

  obterTermos(){
    return this.api.get("/termos");
  }
}