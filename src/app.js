import { inject, computedFrom } from 'aurelia-framework';
import { TermoApi } from "./termo-api";

@inject(TermoApi)
export class App {
  constructor(termoApi) {
    this.termoApi = termoApi;
    this.termos = [];
    this.termosExibicao = [];
  }
  
  attached() {
    this.obterTermos();
  }

  obterTermos() {
    this.termoApi.obterTermos().then(resposta => resposta.json()).then(resposta => {
      this.termos = resposta;
      this.termosExibicao = this.termos;
    });
  }

  abrirDialogo() {
    this.dialogoDeCriacaoDeTermo.abrirDialogo();
  }
}
