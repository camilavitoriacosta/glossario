import { inject, json } from 'aurelia-framework';
import { TermoApi } from '../../termo-api';

@inject(TermoApi)
export class ListaTermos {

  constructor(termoApi){
    this.termoApi = termoApi;
    this.obterTermos();
  }
  
  attached() {
    this.obterTermos();
  }

  obterTermos(){
    this.termoApi.obterTermos().then(resposta => resposta.json()).then(resposta => this.termos = resposta);
  }
}