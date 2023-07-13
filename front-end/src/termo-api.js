import { inject } from 'aurelia-framework';
import { Api } from './api';

@inject(Api)
export class TermoApi {

  constructor(api) {
    this.api = api;
  }

  obterTermos() {
    return this.api.get("/termos");
  }

  salvarTermo(termo) {
    return this.api.post("/termos/", termo);
  }

  editarTermo(id, termo) {
    return this.api.put("/termos/", id, termo);
  }
}