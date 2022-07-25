import * as internal from "stream"
import { Lote } from "./Lote";
import { RedeSocial } from "./RedeSocial";
import { Palestrante } from "./Palestrante";

export interface Evento {
  id: number;
  local: string;
  dataEvento?: Date;
  tema: string;
  quantidadePessoas: number;
  lote: string;
  urlImagem: string;
  lotes: Lote[];
  redesSociais: RedeSocial[];
  palestrantesEventos: Palestrante[];
}
