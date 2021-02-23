CREATE TABLE IF NOT EXISTS public.poll_answers
(
    id                 int GENERATED ALWAYS AS IDENTITY,
    poll_option_id     int       NOt NULL,
    user_id            int       NOT NULL,

    created_date       timestamp NOT NULL DEFAULT timezone('utc'::text, now()),
    last_modified_date timestamp NOT NULL DEFAULT timezone('utc'::text, now()),

    CONSTRAINT poll_answers_pk PRIMARY KEY (id),
    CONSTRAINT poll_answers_poll_options_fk FOREIGN KEY (poll_option_id) REFERENCES public.poll_options (id),
    CONSTRAINT poll_answers_users_fk FOREIGN KEY (user_id) REFERENCES public.users (id)
)