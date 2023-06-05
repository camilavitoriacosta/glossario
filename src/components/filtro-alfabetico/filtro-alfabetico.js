import { bindable, inject } from 'aurelia-framework';
import { TermoApi } from '../../termo-api';


@inject(TermoApi)
export class FiltroAlfabetico {
  @bindable controladorListaTermos;
  letraSelecionada = '';
  termos = [];
  
  constructor(termoApi) {
    this.letrasAlfabeto = [
      "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R",
      "S", "T", "U", "V", "W", "X", "Y", "Z"
    ];
    this.letraSelecionada = this.letrasAlfabeto[0];
    this.termoApi = termoApi;
  }

  attached(){
    this.termoApi.obterTermos().then(resposta => resposta.json()).then(resposta => {
      this.termos = resposta;
    });
  }

  filtrar() {
    this.controladorListaTermos.termos = this.termos.filter(termo => termo.termo.charAt(0).toUpperCase() == this.letraSelecionada);
  }
}