import { IntlRaw, GetLocalizedMessage } from "./localization";
export { IntlRaw as Localize, GetLocalizedMessage }

export const classes = (base: string, input?: (string | false | undefined)[]): string => {
    const list = input && input.filter((condition: string | boolean | undefined) => typeof condition === "string").join(" ");
    return `${base} ${list}`;
}