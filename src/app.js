import { inject } from 'aurelia-framework';
import { TermoApi } from './termo-api';

@inject(TermoApi)
export class App {

  constructor(termoApi){
    this.termoApi = termoApi;
    this.termos = this.termoApi.obterTermos();
  }
}
