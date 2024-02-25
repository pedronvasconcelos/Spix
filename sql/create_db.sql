CREATE TABLE users (
    user_id UUID PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    birth_date DATE,
    country VARCHAR(50),
    city VARCHAR(50),
    user_language INT,  
    email VARCHAR(255) NOT NULL,
    biography TEXT,
    email_is_verified BOOLEAN,
    is_active BOOLEAN,
    user_location TEXT,
    website VARCHAR(255),
    created_at timestamp with time zone,
    updated_at timestamp with time zone
);

CREATE TABLE spixers (
    spixer_id UUID PRIMARY KEY,
    content VARCHAR(280),  
    likes_count INT DEFAULT 0,
    created_at timestamp with time zone,
    user_id UUID,
    active BOOLEAN,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

CREATE TABLE spixer_likes (
    like_id UUID PRIMARY KEY,
    spixer_id UUID,
    user_id UUID,
    created_at timestamp WITH TIME ZONE,
    FOREIGN KEY (spixer_id) REFERENCES spixers(spixer_id) ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

CREATE TABLE user_following (
    user_id UUID NOT NULL,
    following_id UUID NOT NULL,

    CONSTRAINT pk_user_following PRIMARY KEY (user_id, following_id),

    CONSTRAINT fk_user_following_user
        FOREIGN KEY (user_id) 
        REFERENCES users (user_id)
        ON DELETE RESTRICT,

    CONSTRAINT fk_user_following_following
        FOREIGN KEY (following_id) 
        REFERENCES users (user_id)
        ON DELETE RESTRICT
);
