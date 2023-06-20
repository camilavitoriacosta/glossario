import { bindable } from 'aurelia-framework';

export class ListaTermos {
  @bindable termos;
  @bindable dialogoDeEdicaoDeTermo;

  get possuiTermos() {
    return this.termos.length > 0;
  }

  abrirDialogoEdicao(termo) {
    this.dialogoDeEdicaoDeTermo.abrirDialogoEdicao(termo);
  }
}