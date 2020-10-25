CREATE TABLE IF NOT EXISTS public.userroles
(
    id               int                         NOT NULL,
    name             varchar                     NOT NULL,
    createddate      timestamp without time zone NOT NULL DEFAULT timezone('utc'::text, now()),
    lastmodifieddate timestamp without time zone NOT NULL DEFAULT timezone('utc'::text, now()),

    CONSTRAINT user_roles_pk PRIMARY KEY (id)
)