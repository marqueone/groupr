import React, { FC, Fragment } from 'react';
import { FormattedMessage, injectIntl, useIntl } from 'react-intl';
import AppLocale from '../constants';

interface Props { 
    id: string
}

const InjectMessage: FC<any> = props => <FormattedMessage {...props} />;

export default injectIntl(InjectMessage, {
    forwardRef: false
});

export const IntlRaw: FC<Props> = props => {
    const intl = useIntl();
    const { id } = props;

    const message = intl.formatMessage({ id });
    return <Fragment>{message}</Fragment>
}

export const GetLocalizedMessage = (messageId: string): string => {
    const locale = localStorage.getItem("locale") as string
    const currentLocalization = AppLocale[locale];
    const message = currentLocalization[messageId];

    return message;
}