import { bindable } from 'aurelia-framework';

const _ = require("lodash");

export class OrdenacaoAlfabetica {
  @bindable termosExibicao;

  tiposDeOrdenacao = [
    { id: 0, label: "A - Z", ordenar: (termos) => { this.termosExibicao = _.orderBy(termos, ['titulo'], ['asc']) } },
    { id: 1, label: "Z - A", ordenar: (termos) => { this.termosExibicao = _.orderBy(termos, ['titulo'], ['desc']) } }
  ]

  tipoOrdenacaoSelecionado = this.tiposDeOrdenacao[0];

  ordenarTermos() {
    this.tipoOrdenacaoSelecionado.ordenar(this.termosExibicao);
  }
}