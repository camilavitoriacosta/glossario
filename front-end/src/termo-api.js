import { inject } from 'aurelia-framework';
import { Api } from './api';

@inject(Api)
export class TermoApi {
  url = "termos";

  constructor(api) {
    this.api = api;
  }

  obterTermos() {
    return this.api.get(this.url);
  }

  salvarTermo(termo) {
    return this.api.post(this.url, termo);
  }

  editarTermo(termo) {
    return this.api.put(this.url, termo);
  }
}