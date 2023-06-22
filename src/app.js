import { inject } from 'aurelia-framework';
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
      this.termos.forEach(elemento => {
        elemento.termo =  _.capitalize(elemento.termo);
      });
      this.termos = _.orderBy(this.termos, ['termo'], ['asc']);
      this.termosExibicao = this.termos;
    });
  }

  abrirDialogo() {
    this.dialogoDeCriacaoDeTermo.abrirDialogo();
  }
}
