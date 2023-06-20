import { bindable } from 'aurelia-framework';


export class FiltroAlfabetico {
  @bindable termos;
  @bindable termosExibicao;

  letraSelecionada = '';

  constructor() {
    this.letrasAlfabeto = [
      "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R",
      "S", "T", "U", "V", "W", "X", "Y", "Z"
    ];
    this.letraSelecionada = this.letrasAlfabeto[0];
  }

  filtrar() {
    this.termosExibicao = this.termos.filter(termo => termo.termo.charAt(0).toUpperCase() == this.letraSelecionada);
  }
}