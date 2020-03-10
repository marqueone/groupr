import english from "./localization/en-ca";
import french from "./localization/fr-ca";

const AppLocale: { [index: string]: Record<string, string> } = {
    en: english,
    fr: french,
};

export default AppLocale;