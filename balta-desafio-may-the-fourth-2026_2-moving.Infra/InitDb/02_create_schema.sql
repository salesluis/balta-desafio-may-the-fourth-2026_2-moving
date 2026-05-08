CREATE TABLE boxes (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    number INT NOT NULL UNIQUE,  -- "Caixa 7"
    label TEXT,                  -- nome amigável opcional
    created_at TIMESTAMPTZ DEFAULT now()
);

CREATE TABLE items (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    box_id UUID NOT NULL REFERENCES boxes(id),
    description TEXT NOT NULL,          -- "carregador do notebook Dell"
    embedding VECTOR(768) NOT NULL,     -- embedding da description
    created_at TIMESTAMPTZ DEFAULT now()
);

CREATE INDEX ON items USING hnsw (embedding vector_cosine_ops);