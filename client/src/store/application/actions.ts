import { Context } from "..";

export function changeMessage({ state }: Context, newmessage: string) {
    state.sample.message = newmessage;
}