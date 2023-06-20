import { bindable } from 'aurelia-framework';

export class ListaTermos {
  @bindable termos;

  get possuiTermos(){
    return this.termos.length > 0;
  }
}