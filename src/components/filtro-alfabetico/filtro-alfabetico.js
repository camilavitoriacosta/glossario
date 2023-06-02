import { bindable } from 'aurelia-framework';

export class FiltroAlfabetico {
  @bindable controladorListaTermos;
  letraSelecionada = '';
  termos = [];
  
  constructor() {
    this.letrasAlfabeto = [
      "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R",
      "S", "T", "U", "V", "W", "X", "Y", "Z"
    ];
    this.letraSelecionada = this.letrasAlfabeto[0];
  }

  attached(){
    this.termos = this.controladorListaTermos.termos;
  }

  filtrar() {
    this.controladorListaTermos.termos = this.termos.filter(termo => termo.termo.charAt(0).toUpperCase() == this.letraSelecionada);
    console.log(this.termos);
  }
}