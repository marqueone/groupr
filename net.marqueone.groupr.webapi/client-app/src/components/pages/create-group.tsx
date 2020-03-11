import React, { FC, PureComponent } from "react";
import withAuthenticatedLayout from "components/layout/authenticated";
import { Localize } from "helpers";
import { Formik, Field, Form, ErrorMessage } from "formik";
import * as yup from "yup";
import { GetLocalizedMessage } from "helpers";
import axios from "axios";


class CreateGroup extends PureComponent {
    onSubmit = (data: any) => {
debugger;
        const payload = {
            name: data.name,
            description: data.description,
            userId: "e561a1b8-c520-4505-b675-8c1eefabfea0"
        }

        axios({
            method: 'post',
            url: '/_api/group/create',
            data: payload,
        })
            .then(function (response) {
                //handle success
                console.log(response);
            })
            .catch(function (response) {
                //handle error
                console.log(response);
            });
    }

    render() {
        const validationSchema = yup.object({
            name: yup.string().required(GetLocalizedMessage("error.name")).max(64, GetLocalizedMessage("error.name.length")),
            description: yup.string().max(256, GetLocalizedMessage("error.description.length"))
        });

        return (
            <div className="container main-body">

                <h1><Localize id="create.title" /></h1>
                <p><Localize id="create.description" /></p>

                <div>
                    <Formik
                        initialValues={{ name: "", description: "" }}
                        validationSchema={validationSchema}
                        onSubmit={(data, { setSubmitting }) => {
                            setSubmitting(true);
                            
                            this.onSubmit(data);

                            setSubmitting(false);
                        }}
                    >
                        {({ values, errors, isSubmitting }) => (
                            <Form>
                                <div className="form-group">
                                    <label className="control-label"><Localize id="general.label.name" />:</label>
                                    <Field name="name" className="form-control m-b" />
                                    <span className="invalid-feedback"><ErrorMessage name="name" /></span>
                                </div>
                                <div className="form-group">
                                    <label className="control-label"><Localize id="general.label.description" />:</label>
                                    <Field name="description" className="form-control m-b" />
                                    <span className="invalid-feedback"><ErrorMessage name="description" /></span>
                                </div>
                                <div className="float-right">
                                    <button
                                        className="btn btn-primary"
                                        id="create"
                                        type="submit"
                                        disabled={isSubmitting}
                                    ><Localize id="create" /></button>&nbsp;
                            <button
                                        className="btn btn-secondary"
                                        id="clear"
                                        type="reset"
                                        disabled={isSubmitting}
                                    ><Localize id="general.cancel" /></button>
                                </div>

                                <br />
                                <pre>{JSON.stringify(values, null, 2)}</pre>
                                <pre>{JSON.stringify(errors, null, 2)}</pre>
                            </Form>
                        )}
                    </Formik>
                </div>
            </div >
        )
    }
}

export default withAuthenticatedLayout(CreateGroup);