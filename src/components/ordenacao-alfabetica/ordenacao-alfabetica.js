import { bindable } from 'aurelia-framework';

const _ = require("lodash");

export class OrdenacaoAlfabetica {
  @bindable termosExibicao;

  tiposDeOrdenacao = [
    { id: 0, label: "A - Z", ordenar: (termos) => { this.termosExibicao = _.orderBy(termos, ['termo'], ['asc']) } },
    { id: 1, label: "Z - A", ordenar: (termos) => { this.termosExibicao = _.orderBy(termos, ['termo'], ['desc']) } }
  ]

  tipoOrdenacaoSelecionado = this.tiposDeOrdenacao[0];

  ordenarTermos() {
    this.tipoOrdenacaoSelecionado.ordenar(this.termosExibicao);
  }
}