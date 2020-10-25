CREATE TABLE IF NOT EXISTS public.users
(
    id               int                         NOT NULL GENERATED ALWAYS AS IDENTITY,
    roleid           int                         NOT NULL,
    email            text                        NOT NULL,
    passwordhash    text,
    firstname        text,
    lastname         text,
    createddate      timestamp without time zone NOT NULL DEFAULT timezone('utc'::text, now()),
    lastmodifieddate timestamp without time zone NOT NULL DEFAULT timezone('utc'::text, now()),

    CONSTRAINT users_pk PRIMARY KEY (id),
    CONSTRAINT users_user_roles_fk FOREIGN KEY (roleid) REFERENCES public.userroles (id)
)